const setup = () => {
    let btnToon = document.querySelector("#btnToon");
    btnToon.addEventListener("click", toon);
};

const toon = () => {
    let Roker=document.querySelector("#IsRoker");
    if (Roker.checked) {
        console.log("is roker");
    } else {
        console.log("is geen roker");
    }

    let NL = document.getElementById("NL");
    if(NL.checked)
    {
        console.log("moedertaal is "+NL.value);
    }

    let FR = document.getElementById("FR");
    if(FR.checked)
    {
        console.log("moedertaal is "+FR.value);
    }

    let EN = document.getElementById("EN");
    if(EN.checked)
    {
        console.log("moedertaal is "+EN.value);
    }

    let Buurland=document.querySelector("#favorieteBuurland");
    let selectedIndex=Buurland.selectedIndex;
    let option=Buurland.options[selectedIndex];
    console.log("favoriete buurland is "+option.text);


    let text="bestelling bestaat uit ";
    for (let i=0;i<bestelling.options.length;i++) {
        option=bestelling.options[i];
        if (option.selected) {
            text+=option.text+" ";
        }
    }

    console.log(text);

};

window.addEventListener("load", setup);