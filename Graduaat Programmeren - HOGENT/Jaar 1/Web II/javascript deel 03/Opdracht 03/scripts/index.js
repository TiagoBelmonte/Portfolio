const setup = () => {
	// deze code wordt pas uitgevoerd als de pagina volledig is ingeladen

    let btnWijzig = document.getElementById("btnWijzig");
    btnWijzig.addEventListener("click", wijzig);

}

const  wijzig = () =>
{
    let pElement=document.getElementById("txtOutput");
    pElement.textContent="Welkom!";
}

window.addEventListener("load", setup);