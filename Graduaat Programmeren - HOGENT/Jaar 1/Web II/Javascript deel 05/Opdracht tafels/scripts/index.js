const setup = () => {
    let btnGo = document.getElementById("Go");
    btnGo.addEventListener("click", addTafel);

};

const addTafel= () =>{

    let getal = parseInt(document.getElementById("txtGetal"));
};

const NieweTafel = (getal) => {

    let Head=`<h1 class="hoofd">Tafel van ${getal}</h1>`;

    let Inhoud="";
    for (let i=1;i<=10;i++) {
        let product = i*getal;
        let Regel=`<p>${getal} x ${i} = ${product}</p>`;
        Inhoud+=Regel;
    }

    let tafel=`<div class="tafel">${Head}${Inhoud}</div>`;

    let Tafels = document.getElementById("Tafels");
    Tafels.innerHTML+=tafel;

};

window.addEventListener("load", setup);