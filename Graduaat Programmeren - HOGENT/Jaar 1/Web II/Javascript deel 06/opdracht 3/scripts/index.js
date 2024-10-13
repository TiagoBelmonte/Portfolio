const setup = () => {
	// deze code wordt pas uitgevoerd als de pagina volledig is ingeladen

    let btnWijzig = document.getElementById("btnWijzig");
    btnWijzig.addEventListener("click", wijzig);

}


const wijzig = () => {
    let txtInput = document.getElementById("txtInput");
    let src = txtInput.value;

    let afbeelding = document.getElementById("img");
    afbeelding.setAttribute("src", src);
}
window.addEventListener("load", setup);