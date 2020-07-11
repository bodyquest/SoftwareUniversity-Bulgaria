export default function createHTML(type, content, attributes){
    const result = document.createElement(type);

    if (attributes !== undefined) {
        Object.assign(result, attributes);
    }

    if (Array.isArray(content)) {
        content.forEach(append);
    }else if(content !== null && content !== undefined){
        append(content);
    }

    function append(node) {
        if (typeof node === "string" || typeof node === "number") {
            node = document.createTextNode(node);
        }

        result.appendChild(node);
    }

    return result;
}