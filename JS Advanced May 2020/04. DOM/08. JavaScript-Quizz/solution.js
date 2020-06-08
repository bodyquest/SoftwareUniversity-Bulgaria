function solve() {
  let quizzes = document.getElementById("quizzie");
  let sections = document.getElementsByTagName("section");
  let result = document.querySelector(".results-inner h1");

  const correctAnswers = ["onclick", "JSON.stringify()", "A programming API for HTML and XML documents"];
  let userAnswers = 0;
  let currentStep = 0;

  let handler = (e) => {
    if (e.target.className === "answer-text") {
      
      sections[currentStep].style.display = "none";

      let isCorrect = correctAnswers
        .some(answer => answer === e.target.innerHTML);

      if (isCorrect) {
        userAnswers++;
      }

      currentStep++;
      if (currentStep < correctAnswers.length) {
        sections[currentStep].style.display = "block";
      }

      if (currentStep === 3) {
        quizzes.removeEventListener("click", handler);
        document.querySelector("#results").style.display = "block";

        result.innerHTML = correctAnswers.length == userAnswers 
        ? "You are recognized as top JavaScript fan!" 
        : `You have ${userAnswers} right answers`;
      }
    }

  };

  quizzes.addEventListener("click", handler);
}
