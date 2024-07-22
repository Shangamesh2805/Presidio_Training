const letters = ['K', 'C', 'Y', 'O', 'G', 'R', 'S'];
const centerLetter = 'O';
const predefinedWords = ["BOOK", "COOK", "ROOK", "CROOK", "SCOOK","SORRY"];
let currentWord = "";
let score = 0;

document.addEventListener("DOMContentLoaded", () => {
    const lettersContainer = document.querySelector(".letters");
    const wordInput = document.getElementById("word-input");
    const message = document.getElementById("message");
    const scoreDisplay = document.getElementById("score");

    
    letters.forEach((letter, index) => {
        const button = document.createElement("button");
        button.textContent = letter;
        if (letter === centerLetter) {
            button.classList.add("center");
        }
        button.addEventListener("click", () => {
            currentWord += letter;
            wordInput.value = currentWord;
        });
        lettersContainer.appendChild(button);
    });

    
    document.getElementById("delete").addEventListener("click", () => {
        currentWord = currentWord.slice(0, -1);
        wordInput.value = currentWord;
    });

   
    document.getElementById("enter").addEventListener("click", () => {
        if (currentWord.length >= 4 && currentWord.includes(centerLetter)) {
            if (predefinedWords.includes(currentWord)) {
                const wordScore = currentWord.length;
                score += wordScore;
                scoreDisplay.textContent = score;
                message.textContent = `Great! You scored ${wordScore} points.`;
                message.style.color = 'green';
            } else {
                message.textContent = "Invalid word. Try again!";
                message.style.color = 'red';
            }
        } else {
            message.textContent = "Word must be at least 4 letters and include the center letter!";
            message.style.color = 'red';
        }
        currentWord = "";
        wordInput.value = "";
    });
});
