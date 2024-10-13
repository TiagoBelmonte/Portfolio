const setup = () => {
    // deze code wordt pas uitgevoerd als de pagina volledig is ingeladen
    let links = document.querySelectorAll("#lstIngredients");
    for(let i = 0;i<links.length;i++)
    {
        links[i].addEventListener("click",btnVerwijder);
    }
}

const btnVerwijder= (event) => {
    let link = event.target;

    let lijst = link.parentElement.parentElement;
    lijst.removeChild(link.parentElement);


}

window.addEventListener("load", setup);