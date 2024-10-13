const setup = () => {
    // deze code wordt pas uitgevoerd als de pagina volledig is ingeladen
    let ingredienten = document.querySelectorAll("#lstIngredients");
    for(let i = 0;i<ingredienten.length;i++)
    {
        ingredienten[i].addEventListener("click",btnVerwijder);
    }
}

const btnVerwijder= (event) => {
    let ingredienten = event.target.parentElement;
    ingredienten.removeChild(event.target);
}

window.addEventListener("load", setup);