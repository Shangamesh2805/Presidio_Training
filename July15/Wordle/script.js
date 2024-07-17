document.addEventListener('DOMContentLoaded', () => {
    const WORD = 'apple'; // The word to guess
    const MAX_ATTEMPTS = 6;
    let attempts = 0;
    let currentGuess = '';

    const gameBoard = document.getElementById('game-board');
    const keys = document.querySelectorAll('.key');
    const enterButton = document.getElementById('enter');
    const deleteButton = document.getElementById('delete');

    // Create the game board
    for (let i = 0; i < MAX_ATTEMPTS * 5; i++) {
        const cell = document.createElement('div');
        cell.classList.add('cell');
        gameBoard.appendChild(cell);
    }

    // Handle virtual keyboard input
    keys.forEach(key => {
        key.addEventListener('click', () => {
            if (currentGuess.length < 5) {
                currentGuess += key.textContent.toLowerCase();
                updateCurrentGuess();
            }
        });
    });

    // Handle Enter button
    enterButton.addEventListener('click', () => {
        if (currentGuess.length === 5) {
            if (attempts >= MAX_ATTEMPTS) {
                alert('No more attempts left!');
                return;
            }
            updateBoard(currentGuess);
            attempts++;
            currentGuess = '';
            if (currentGuess === WORD) {
                alert('Congratulations! You guessed the word.');
            } else if (attempts === MAX_ATTEMPTS) {
                alert(`Game over! The word was ${WORD}.`);
            }
        } else {
            alert('Guess must be a 5-letter word.');
        }
    });

    // Handle Delete button
    deleteButton.addEventListener('click', () => {
        currentGuess = currentGuess.slice(0, -1);
        updateCurrentGuess();
    });

    // Update the current guess display on the game board
    function updateCurrentGuess() {
        const cells = Array.from(gameBoard.children).slice(attempts * 5, attempts * 5 + 5);
        cells.forEach((cell, index) => {
            cell.textContent = currentGuess[index] || '';
        });
    }

    // Update the game board with the guess
    function updateBoard(guess) {
        const cells = Array.from(gameBoard.children).slice(attempts * 5, attempts * 5 + 5);
        for (let i = 0; i < 5; i++) {
            cells[i].textContent = guess[i];
            if (guess[i] === WORD[i]) {
                cells[i].classList.add('correct');
            } else if (WORD.includes(guess[i])) {
                cells[i].classList.add('present');
            } else {
                cells[i].classList.add('absent');
            }
        }
    }
});
