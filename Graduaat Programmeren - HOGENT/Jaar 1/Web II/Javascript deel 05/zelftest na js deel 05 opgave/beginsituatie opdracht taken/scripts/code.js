let priorities=null; // vervang null door een array met drie string waarden, resp. low, medium en high

const getTextForPriorityLevel = (level) => {
    // geef de tekst terug voor dit priority level (bv. 0 is "low" en 2 is "high")
    // (gebaseerd op het priorities array)
};

const getPriorityLevelForText = (text) => {
    // geef het level terug voor deze priority tekst (bv. "low" is 0 en "high" is 2)
    // of -1 indien de tekst geen geldige priority tekst is.
    // (gebaseerd op het priorities array)
};

const setup = () => {
    // Zorg ervoor dat een klik op de #btnAdd button onze 'addTask' event listener oproept

    // Zorg ervoor dat een klik op een .dot element onze 'filterTasks' event listener oproept

    // Voeg enkele tasks toe, om snel te kunnen testen
    // insertTaskHTML(0, "low priority");
    // insertTaskHTML(1, "medium priority");
    // insertTaskHTML(2, "high priority");
};

const addTask= () => {
    // haal de titel van de task op uit #txtDescription
    let description = ""; // geef description de juiste waarde

    // haal het priority level van de task op uit sldLevel en zet om naar een getal
    let level=0; // vervang 0 door de juiste waarde

    // voeg de HTML voor de task toe
    insertTaskHTML(level, description);

    // maak titel inputveld leeg

};

const insertTaskHTML = (level, description) => {
    // Voeg de HTML code toe aan .tasks voor deze task (level is een Number, description is een string)
    // De task krijgt ook een class volgens het priority level (.low, medium of .high)
    // Om de naam vd class te bekomen op basis van het level gebruik je getTextForPriorityLevel

    // Je hoeft hierbij geen rekening te houden met de actuele filter level!
    // (maw indien wegens de filter enkel 'high' getoond wordt en je voegt een 'low' toe, dan mag deze 'low' zichtbaar zijn)
};

const filterTasks = (event) => {
    // achterhaal op welk .dot element geklikt werd

    // haal de (onzichtbare) tekst op uit dit element

    // zet de tekst om naar een priority level (zodat je een Number hebt)
    // gebruik hiervoor getPriorityLevelForText
    let filterLevel = 2; // vervang 2 door de juiste waarde

    // pas de classes aan van de .task elementen op basis van filterLevel
    adjustForFilter(filterLevel);
};

const adjustForFilter = (filterLevel) => {
    // pas de CSS classes aan van de .task elementen (filterLevel is een Number)

    // je maakt tasks onzichtbaar door hun element de class .hidden te geven
    // om ze zichtbaar te maken, moet je gewoon de class .hidden verwijderen

    // om te weten welke task element je moet filteren (i.e. verbergen), kun je checken
    // of ze bv. de 'medium' class hebben. Je zult wellicht ook 'getTextForPriorityLevel en/of
    // getPriorityLevelForText nodig hebben.
};

// Zorg ervoor dat je setup functie pas wordt uitgevoerd als de DOM-tree klaar is!