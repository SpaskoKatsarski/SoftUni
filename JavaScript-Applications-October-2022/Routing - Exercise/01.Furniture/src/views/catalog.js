import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllItems } from "../api/data.js";

export async function showCatalog(ctx) {
    const items = await getAllItems();
    ctx.render(createCatalogTemp(items));
}

function createCatalogTemp(data) {
    return html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Welcome to Furniture System</h1>
            <p>Select furniture from the catalog to view details.</p>
        </div>
    </div>
    <div class="row space-top">
        ${Object.values(data).map(createItemTemp)}
    </div>`
}

function createItemTemp(item) {
    return html`
        <div class="col-md-4">
            <div class="card text-white bg-primary">
                <div class="card-body">
                    <img src="../../${item.img}" />
                    <p>${item.description}</p>
                    <footer>
                        <p>Price: <span>${item.price} $</span></p>
                    </footer>
                    <div>
                        <a href="#" class="btn btn-info">Details</a>
                    </div>
                </div>
            </div>
        </div>
    `
}