function encodeAndDecodeMessages() {
    // get the text area
    const $textAreasDivs = document
        .querySelectorAll("div#container main#main div");
    
    const $textAreaEncode = $textAreasDivs[0].children[1];
    const $buttonEncode = $textAreasDivs[0].children[2];

    const $textAreaDecode = $textAreasDivs[1].children[1];
    const $buttonDecode = $textAreasDivs[1].children[2];

    $buttonEncode.addEventListener("click", encode);
    $buttonDecode.addEventListener("click", decode);

    function encode() {
        let text = $textAreaEncode.value;
        let encoded = text
            .split("")
            .map(x => String.fromCharCode(x.codePointAt(0) + 1))
            .join("");

        $textAreaEncode.value = "";
        $textAreaDecode.value = encoded;
    }

    function decode() {
        let decoded = $textAreaDecode.value
        .split("")
        .map(x => String.fromCharCode(x.codePointAt(0) - 1))
        .join("");
        $textAreaDecode.value = decoded;
    }
}
