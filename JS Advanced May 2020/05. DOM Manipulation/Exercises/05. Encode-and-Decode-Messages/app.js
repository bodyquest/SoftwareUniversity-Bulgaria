function encodeAndDecodeMessages() {

    // get the text area
    const $textAreasDivs = document
        .querySelectorAll("div#container main#main div");
    
    const $textAreaEncode = $textAreasDivs[0].children[1];
    const $buttonEncode = $textAreasDivs[0].children[2];

    const $textAreaDecode = $textAreasDivs[1].children[1];
    const $buttonDecode = $textAreasDivs[1].children[2];

    $buttonEncode.addEventListener("click", encode);
    $buttonDecode.addEventListener("click", decode);

    function encode() {
        const text = $textAreaEncode.value;
        let encoded = text
            .split("")
            .map(x => String.fromCharCode(x.charCodeAt(0) + 1))
            .join("");

        $textAreaEncode.value = "";
        $textAreaDecode.value = encoded;
    }

    function decode() {
        const text = $textAreaDecode.value;
        $textAreaDecode.value = [...text].
        map((_, i) => text[i] = String.fromCharCode(text[i]
            .charCodeAt(0) - 1))
            .join("");
    }
}
