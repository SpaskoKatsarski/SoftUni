import { html } from "../../node_modules/lit-html/lit-html.js";
import { getMyItems } from "../api/data.js";

export async function showMyFurniture(ctx) {
    const items = await getMyItems();
    ctx.render(createMyItemsTemp(items));
}

function createMyItemsTemp(items) {
    return html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>My Furniture</h1>
            <p>This is a list of your publications.</p>
        </div>
    </div>
    <div class="row space-top">
        ${Object.values(items).map(createSingleItemTemp)}
    </div>
    `;
}

function createSingleItemTemp(item) {
    return html`
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src="../../${item.img}" />
                <p>${item.img}</p>
                <footer>
                    <p>Price: <span>${item.price} $</span></p>
                </footer>
                <div>
                    <a href="/details/${item._id}" class="btn btn-info">Details</a>
                </div>
            </div>
        </div>
    </div>
    `;
}