import { html } from "../../node_modules/lit-html/lit-html.js";

export async function showCatalog(ctx) {
    const template = html`<h1>Hello There from catalog!</h1>`;
    ctx.render(template);
    console.log('catalog view');
}