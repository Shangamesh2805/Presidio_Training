# 5) Credit card validation - Luhn check algorithm




def is_luhn_valid(card_number):
    card_number = ''.join(c for c in card_number if c.isdigit())
    if not card_number:
        return False

    digits = [int(d) for d in card_number]
    digits.reverse()
    checksum = 0

    for i, digit in enumerate(digits):
        if i % 2 != 0:
            doubled_digit = digit * 2
            checksum += doubled_digit if doubled_digit < 10 else doubled_digit - 9

    checksum += sum(digits[::2])
    return checksum % 10 == 0

if __name__ == "__main__":
    card_number = input("Enter Your Card Number: ")
    if is_luhn_valid(card_number):
        print("Valid card number")
    else:
        print("Invalid card number")

