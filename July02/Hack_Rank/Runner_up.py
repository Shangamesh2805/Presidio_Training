if __name__ == '__main__':
    n = int(input())
    arr = map(int, input().split())
    arr=list(arr)
    m=max(arr)
    ans=-100
    
    for i in arr:
        if i>ans and i!=m:
            ans=i
        
    print(ans)
