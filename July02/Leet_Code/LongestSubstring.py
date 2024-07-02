class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        
        l=[]
        c1=0
        c=0
        a=0
        for j in range(len(s)):
            c1=0
            l=[]
            for i in range(j,len(s)):
                if s[i] not in l:
                    l.append(s[i])
                    c1+=1
                    if c1>=c:
                        c=c1

                else:
                    break
        
        return c
                