class Solution:
    def canJump(self, nums: List[int]) -> bool:
        n=len(nums)
        if 0 not in nums or n == 1: 
            return True

        p = nums.index(0)            

        for i in range(n):
            if i <= p and  i + nums[i] > p: 
                p = i + nums[i]

            if i == p and not nums[i]: 
                return False
            if p >= n-1: 
                return True

        return True
        
            
