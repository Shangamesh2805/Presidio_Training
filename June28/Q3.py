# 3) Sort sore and name of players print the top 10

players = []  


while True:
    name = input("Enter player name (or 'q' to quit): ")
    if name.lower() == 'q':
        break

    try:
        score = int(input("Enter player score: "))
        players.append((name, score))  
    except ValueError:
        print("Invalid score. Please enter an integer.")
        
# print(players)

players.sort(key=lambda player: player[1], reverse=True)

print("\nTop Players:")
print()
for i, player in enumerate(players):
    if i < 10:
        print(f"{i+1}. {player[0]}: {player[1]}")
