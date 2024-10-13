const setup = () =>{
printGreeting("Bezoeker");
}

const printGreeting = (naam) => {
    console.log("Hello " + naam);
}

window.addEventListener("load", setup);