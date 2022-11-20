export function showDetails(ctx) {
    ctx.render(`Details about product from category: "${ctx.params.category}" with ID: "${ctx.params.productId}"`);
}