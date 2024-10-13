const setup = () => {
    // registeer click event listener 'voegToe' bij #btnAdd
    let btnAdd = document.querySelector("#btnAdd");
    btnAdd.addEventListener("click", voegToe);

    // registreer click event listener 'wisAlles' bij #btnClear
    let btnClear = document.querySelector("#btnClear");
    btnClear.addEventListener("click", wisAlles);

    // registreer click event listener 'maakBelangrijk' bij elke <li> in .lstIngredients
    let lstIngredients = document.querySelector("#lstIngredients");
    lstIngredients.addEventListener("click", maakBelangrijk);
}

const voegToe = () => {
    // Lees de tekst uit het textveld en voeg nieuw <li> element toe
    let ingredient = document.querySelector("#txtInput");
    let lstIngredients = document.querySelector("#lstIngredients");

    lstIngredients.insertAdjacentHTML("beforeend", `<li>${ingredient.value}</li>`);
}

const wisAlles = () => {
    // Wis alle ingredienten
    // Je kunt dit doen door alle de .innerHTML van #lstIngredients een lege string in te stellen
    let lstIngredients = document.querySelector("#lstIngredients");
    lstIngredients.innerHTML="";
}

const maakBelangrijk = (event) => {

    event.target.classList.add("belangrijk");
}

//verschil even.target en event.currentTarget

window.addEventListener('load',setup);



















