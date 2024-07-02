# exception_handling

def divide(a, b):
    try:
        result = a / b
    except ZeroDivisionError:
        print("Error: Division by zero is not allowed.")
        return None
    except TypeError:
        print("Error: Invalid input type. Please enter numbers.")
        return None
    else:
        print(f"The result of {a} divided by {b} is {result}")
        return result
    finally:
        print("Execution of divide function complete.")


if __name__ == "__main__":
    divide(10, 2)
    divide(10, 0)
    divide(10, "a")
