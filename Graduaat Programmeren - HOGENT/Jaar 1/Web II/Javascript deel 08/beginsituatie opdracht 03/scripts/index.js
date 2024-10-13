const setup = () => {
    // deze code wordt pas uitgevoerd als de pagina volledig is ingeladen
    let links = document.querySelectorAll("#lstIngredients");
    for(let i = 0;i<links.length;i++)
    {
        links[i].addEventListener("click",btnVerwijder);
    }

    let VoegToe = document.getElementById("btnAdd")
    VoegToe.addEventListener("click",btnVoegToe)
}

const btnVerwijder= (event) => {
    let link = event.target;

    let lijst = link.parentElement.parentElement;
    lijst.removeChild(link.parentElement);


}

const btnVoegToe = () => {
    // Lees de tekst uit het textveld en voeg nieuw <li> element toe
    let txtInput = document.querySelector("#txtInput");
    let ingredient = txtInput.value;
    let lstIngredients = document.querySelector("#lstIngredients");

    lstIngredients.insertAdjacentHTML("beforeend", `<li>${ingredient} <a href="#">verwijder</a></li>`);
}

window.addEventListener("load", setup);