n, m = map(int, input().split())

for i in range(n//2):
    print(('.|.'*((i*2)+1)).center(m, '-'))

print('WELCOME'.center(m, '-'))

for i in range(n//2-1, -1, -1):
    print(('.|.'*((i*2)+1)).center(m, '-'))