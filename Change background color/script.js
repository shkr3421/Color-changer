const boxes=document.querySelectorAll(".box");
const body = document.body;

boxes.forEach((box)=>{
    box.addEventListener("click",()=>{
        const color=box.getAttribute("id");
        if(color==="grey"){
            body.style.backgroundColor = "grey";
        }
        if(color==="white"){
            body.style.backgroundColor = "white";
        }
        if(color==="blue"){
            body.style.backgroundColor = "blue";
        }
        if(color==="yellow"){
            body.style.backgroundColor = "yellow";
        }
    });
});