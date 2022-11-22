import { html } from "../../node_modules/lit-html/lit-html.js";
import { getDetails } from "../api/data.js";
import { deleteItem } from "../api/data.js";

let context = null;

export async function showDetails(ctx) {
    context = ctx;

    const itemDetails = await getDetails(ctx.params.id);
    const userData = JSON.parse(sessionStorage.getItem('userData'));

    ctx.render(createDetailsTemp(itemDetails, userData));
}

function createDetailsTemp(item, userData) {
    let isOwner = null;

    if (userData == undefined) {
        isOwner = false;
    } else if (userData._id === item._ownerId) {
        isOwner = true;
    } else {
        isOwner = false;
    }

    return html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Furniture Details</h1>
        </div>
    </div>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="card text-white bg-primary">
                <div class="card-body">
                    <img src="../../${item.img}" />
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <p>Make: <span>${item.make}</span></p>
            <p>Model: <span>${item.model}</span></p>
            <p>Year: <span>${item.year}</span></p>
            <p>Description: <span>${item.description}</span></p>
            <p>Price: <span>${item.price}</span></p>
            <p>Material: <span>${item.material}</span></p>
            ${isOwner ? html`<div>
                <a href="/edit/${item._id}" class="btn btn-info">Edit</a>
                <a @click=${onDelete.bind(null, item._id)} href="javascript:void(0)" class="btn btn-red">Delete</a>
            </div>
            ` 
            : ''}
        </div>
    </div>
    `;
}

async function onDelete(id) {
    await deleteItem(id);
    context.page.redirect('/');
}