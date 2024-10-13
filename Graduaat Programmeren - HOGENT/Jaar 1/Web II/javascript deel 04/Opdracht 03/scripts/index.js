const setup = () => {
	// deze code wordt pas uitgevoerd als de pagina volledig is ingeladen

    let divke = document.getElementById("divke");

    divke.addEventListener("click",VeranderKleur);
}

const VeranderKleur = () =>
{
    let divke = document.getElementById("divke");
    divke.style.backgroundColor="red";
}

window.addEventListener("load", setup);