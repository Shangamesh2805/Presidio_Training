# 4) Application to play the Cow and Bull game maintain score as well. - reff - Wordle of New York Times




def get_guess():
   
    while True:
        guess = input("Enter your 4-digit guess (or 'q' to quit): ")
        if guess.lower() == 'q':
            return None
        if not guess.isdigit() or len(guess) != 4:
            print("Invalid guess. Please enter a 4-digit number.")
            continue
        if len(set(guess)) != 4:
            print("Digits cannot be repeated. Please enter a unique 4-digit number.")
            continue
        return guess

def calculate_cows_and_bulls(num, guess):
    
    cows, bulls = 0, 0
    for i in range(4):
        if num[i] == guess[i]:
            bulls += 1
        elif num[i] in guess:
            cows += 1
    return cows, bulls

def play_cow_and_bull(max_guesses=10):
    
    while True:
        
        num=input('Enter a unique number 4 digit number :')
        if len(set(num))!=4:
            print("Please a valid non-repeating 4 digit number.")
        else:
            break
        
    guesses = 0
    score = 0 

    while guesses < max_guesses:
        guess = get_guess()
        if guess is None:
            return None  
        guesses += 1

        cows, bulls = calculate_cows_and_bulls(num, guess)

        if bulls == 4:
            score = max_guesses - guesses + 1 
            print(f"You guessed it! The secret number was {num}.")
            print(f"You got {cows} Cows and {bulls} Bulls in {guesses} guesses.")
            print(f"Your score for this round is: {score}")
            return score
        else:
            print(f"You got {cows} Cows and {bulls} Bulls.")

    print(f"You ran out of guesses. The secret number was {num}.")
    return 0  # Score 0 for running out of guesses

def main():
    
    total_score = 0
    while True:
        print("\nWelcome to Cow and Bull!")
        print("*"*20)
        score = play_cow_and_bull()
        if score is not None:
            total_score += score
        print(f"\nYour total score is: {total_score}")

        play_again = input("Play again? (y/n): ")
        if play_again.lower() != 'y':
            break

if __name__ == "__main__":
    main()

        