let userScore=0;
let compScore=0;

const choices = document.querySelectorAll(".choice");
const msg = document.querySelector("#msg");

const userScorePara = document.querySelector("#user-score");
const computerScorePara = document.querySelector("#comp-score");

const draw= ()=>{
    msg.innerText= "Draw!";
    msg.style.backgroundColor="black";
};
const generateCompChoice=()=>{
    const options=["rock", "paper", "scissors"];
    const randIdx= Math.floor(Math.random()*3);
    return options[randIdx];
};
const showWinner=(userWin, userChoice, computerChoice)=>{
    if(userWin){
        userScore++;
        userScorePara.innerText=userScore;
        msg.innerText=`You won! ${userChoice}, beats ${computerChoice}`;
        msg.style.backgroundColor="green";
    }else{
        compScore++;
        computerScorePara.innerText=compScore;
        msg.innerText=`You lost! ${computerChoice}, beats ${userChoice}`;
        msg.style.backgroundColor="red";
    }
};
const playGame = (userChoice)=>{
    const computerChoice=generateCompChoice();
    if(userChoice===computerChoice) {
        draw();
    }else{
        let userWin=true;
        if(userChoice=="rock"){
            userWin= computerChoice==="paper"? false:true;
        }else if(userChoice=="paper"){
            userWin= computerChoice==="scissors"? false: true;            
        }else{
            userWin= computerChoice==="rock"? false: true;  
        }
        showWinner(userWin, userChoice, computerChoice);
    }
};
choices.forEach((choice)=>{
    choice.addEventListener("click",()=>{
        const userChoice=choice.getAttribute("id");
        playGame(userChoice);
    });
});