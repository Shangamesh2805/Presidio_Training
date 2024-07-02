class Solution:
    def multiply(self, num1: str, num2: str) -> str:
        ans=0
        n=len(num2)-1
        m=1
        for i in range(n,-1,-1):
            temp=int(num2[i])*int(num1)
            ans=ans+(temp*m)
            m=m*10
        return str(ans)