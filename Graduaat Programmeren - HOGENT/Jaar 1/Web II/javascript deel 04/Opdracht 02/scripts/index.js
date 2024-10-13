const setup = () => {
	// deze code wordt pas uitgevoerd als de pagina volledig is ingeladen

    let divke = document.getElementById("divke");

    divke.addEventListener("click",printKlik);
    divke.addEventListener("mouseenter",printEnter);
    divke.addEventListener("mousemove",printMove);
    divke.addEventListener("mouseleave",printLeave);

}

const printKlik = () =>
{
    console.log("klik");
}

const printEnter = () =>
{
    console.log("enter");
}
const printMove = () =>
{
    console.log("move");
}
const printLeave = () =>
{
    console.log("leave");
}

window.addEventListener("load", setup);