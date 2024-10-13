const setup = () => {
	// deze code wordt pas uitgevoerd als de pagina volledig is ingeladen

    let divke = document.getElementById("divke");

    divke.addEventListener("click",printKlik);
}

const printKlik = () =>
{
    console.log("klik");
}

window.addEventListener("load", setup);