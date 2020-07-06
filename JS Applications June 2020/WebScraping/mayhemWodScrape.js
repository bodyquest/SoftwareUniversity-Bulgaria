const puppeteer = require("puppeteer");
const fs = require("fs-extra");

(async () => {
    
    let baseUrl = `https://www.crossfitmayhem.com`;

    try {

        // extract recursively
        const extractWods = async url => {
            const page = await browser.newPage();
            await page.goto(url);
            console.log(`scraping:   ${url}`);

            const wods = await page.evaluate(() =>
            Array.from(document.querySelectorAll("section.BlogList>article"))
                .map(wod => ({
                    date: wod.querySelector(".BlogList-item-title").textContent,
                    content: Array.from(wod.querySelectorAll(".sqs-block-content > p")).reduce((acc, curr) => {
                        acc.push(curr.textContent);
                        return acc;
                    }, [])
                }))
            );
            

            if (wods.length < 1) {
                await page.close();
                return wods;
            }
            else{
                const buttons = await page.$$(".BlogList-pagination-link");
                //const buttons = await page.$$(".BlogList-pagination-link");
                let btnLink = "";
                for (let i = 0; i < buttons.length; i++) {
                    if (buttons.length === 2) {
                        const btn = buttons[i+1];
                        btnLink = await page.evaluate(btn => btn.getAttribute("href"), btn);

                        break;
                    }
                    else{
                        const btn = buttons[i];
                        btnLink = await page.evaluate(btn => btn.getAttribute("href"), btn);

                        break;
                    }
                }

                let nextLink = baseUrl + btnLink;

                await page.close();

                if (btnLink.endsWith("&reversePaginate=true")) {
                    return wods;
                }
                else{
                    // TO DO update file / database
                    // await fs.appendFile("mayhemWods.json", wods);
                    return wods.concat( await extractWods(nextLink));
                }
            }
        };

        const browser = await puppeteer.launch({headless: true});
        let firstUrl = "https://www.crossfitmayhem.com/daily-workout-posts";

        const allWODs = await extractWods(firstUrl);
        console.log(allWODs);

        await fs.writeJSON("mayhemWods.json", allWODs);
        

        await browser.close();
    }
    catch (error) {
        console.log("My Scraping Error: ", error);
    }
})();
