// function AddNum(a,b){
//     return a+b
// }
// //higherOrder Function
// function findSum(c,callbackfunction)
// {
//     let ans=0;
//     for(let value of c){
//         ans=AddNum(ans,value)
//     }
//     return ans;

// }
// let array=[1,2,3,4,5];
// console.log(findSum(array,AddNum))


function checkingEvenNumbers(num)
{
    return num%2==0//boolean
}


function filteringEvenNumbers(numbers,callbackFunc)
{
    let numberArray=[]
    for(let value of numbers)
    {
        if(callbackFunc(value))
            numberArray.push(value)
    }
    return ()=>console.log(numberArray);
}

let arrayOfNumbers=[22,45,99,3,8,44]
// console.log(filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers))
let result=filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers)
result()