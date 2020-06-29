export const renderForm = () => {
    const container = document.getElementById('container')
    container.innerHTML += `
    <form>
        <h2>Add a Variety</h2>
        <label for='name'>Name: </label><br>
        <input type="text" id='name'><br>
        <label for='region'>Region: </label><br>
        <input type="text" id='region'><br>
        <label for='region'>Notes: </label><br>
        <textarea id='notes'></textarea><br>
        <button id='submitForm'>Submit</button>
    </form>`

    const submitBtn = document.querySelector('#submitForm')
    submitBtn.addEventListener('click', (e) => {
        e.preventDefault()
        handleSubmit()
    })
}

const handleSubmit = () => {
    debugger
    const beanVariety = {}
    beanVariety.name = document.querySelector('#name').value
    beanVariety.region = document.querySelector('#region').value
    beanVariety.notes = document.querySelector('#notes').value

    return fetch('https://localhost:5001/api/beanvariety', {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(beanVariety)
    })
}