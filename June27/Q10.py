# 10) Print a pyramid of starts for the number of rows specified

n=int(input("Enter the number of rows for Pyramid: "))

def Pyramid(rows):
    for i in range(1, rows + 1):
        
        for j in range(rows - i):
            print(" ", end="")
    
        for j in range(2 * i - 1):
            print("*", end="")
    
        print("\n")

Pyramid(n)