# 1) Longest Substring Without Repeating Characters. That is in a given string find the longest substring that does not contain any character twice.

a=input("Enter a string : ")

ans=''
temp=''
for i in a:
    if i not in temp:
        temp=temp+i
    else:
        if len(temp)>len(ans):
            ans=temp

print(f"The longest Substring in {a} is ",ans)
    