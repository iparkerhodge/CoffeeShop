import render from './render.js'
import { renderForm } from './form.js'

const url = "https://localhost:5001/api/beanvariety/";

const button = document.querySelector("#run-button");
button.addEventListener("click", () => {
    getAllBeanVarieties()
        .then(beanVarieties => {
            console.log(beanVarieties);
            render(beanVarieties)
            renderForm(beanVarieties)
        })
});

function getAllBeanVarieties() {
    return fetch(url).then(resp => resp.json());
}