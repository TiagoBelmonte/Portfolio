const setup = () => {
    // registeer click event listener 'voegToe' bij #btnAdd
    let btnAdd = document.querySelector("#btnAdd");
    btnAdd.addEventListener("click", voegToe);

    // registreer click event listener 'wisAlles' bij #btnClear
    let btnClear = document.querySelector("#btnClear");
    btnClear.addEventListener("click", wisAlles);

    // registreer click event listener 'maakBelangrijk' bij elke <li> in .lstIngredients
    let lis = document.querySelectorAll("#lstIngredients li");
    for (let i=0;i<lis.length;i++) {
        lis[i].addEventListener("click", maakBelangrijk);
    }
}

const voegToe = () => {
    // Lees de tekst uit het textveld en voeg nieuw <li> element toe
    let txtInput = document.querySelector("#txtInput");
    let ingredient = txtInput.value;
    let lstIngredients = document.querySelector("#lstIngredients");
    lstIngredients.innerHTML+=`<li>${ingredient}</li>`;

    // Probleem A
    // vermits we hier dmv .innerHTML+= eigenlijk alle kinderen van het
    // <ul> element vervangen door kopies (zonder eventlisteners), zal een klik
    // op een bestaand kind geen effect meer hebben.

    // Probleem B
    // vermits we geen event listener koppelen aan het nieuwe kind, zal dit
    // niet reageren op een klik
}

const wisAlles = () => {
    // Wis alle ingredienten
    // Je kunt dit doen door alle de .innerHTML van #lstIngredients een lege string in te stellen
    let lstIngredients = document.querySelector("#lstIngredients");
    lstIngredients.innerHTML="";
}

const maakBelangrijk = (event) => {
    // Geef het geklikte element de CSS class 'belangrijk'
    let li = event.target;
    li.classList.add("belangrijk");
}

window.addEventListener('load',setup);



















