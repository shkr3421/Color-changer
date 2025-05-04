let boxes=document.querySelectorAll(".box");
let reset_btn=document.querySelector("#reset");
let newgame= document.querySelector("#new-game");
let msgContainer= document.querySelector(".msg-con");
let msg= document.querySelector("#msg");

let turn0= true
console.log(boxes);
let patterns=[
    [0,1,2],
    [0,3,6],
    [6,7,8],
    [2,5,8],
    [0,4,8],
    [2,4,6],
    [3,4,5],
    [1,4,7]
];
const resetGame=()=>{
    turn0=true;
    enableBoxes();
    msgContainer.classList.add("hide");
}
const disableBoxes=()=>{
    for(let box of boxes) box.disabled=true;
}
const enableBoxes= ()=>{
    for(let box of boxes){
        box.disabled=false;
        box.innerText="";
    }
}
boxes.forEach((box)=>{
    box.addEventListener("click",()=>{
        if(turn0){
            box.innerHTML="O";
        }else{
            box.innerHTML="X";
        }
        turn0=!turn0;
        box.disabled=true;
        checkWinner();
    });
});
const showWinner=(winner)=>{
    msg.innerText= `Congratulations winner is ${winner}`
    disableBoxes();
    msgContainer.classList.remove("hide"); 
}
let found=false;
const checkWinner = () => {
    let winnerFound = false;

    for (let pattern of patterns) {
        let value1 = boxes[pattern[0]].innerText;
        let value2 = boxes[pattern[1]].innerText;
        let value3 = boxes[pattern[2]].innerText;

        if (value1 !== "" && value1 === value2 && value2 === value3) {
            winnerFound = true;
            showWinner(value1);
            return;
        }
    }

    // Check for draw only if no winner
    let allFilled = true;
    boxes.forEach((box) => {
        if (box.innerText === "") {
            allFilled = false;
        }
    });

    if (allFilled && !winnerFound) {
        isDraw();
    }
};
const isDraw = () => {
    msg.innerText = "It's a Draw!";
    msgContainer.classList.remove("hide");
    disableBoxes();
};
newgame.addEventListener("click",resetGame);
reset_btn.addEventListener("click",resetGame);