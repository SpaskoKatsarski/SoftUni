function solve(input) {
    let objects = JSON.parse(input);
    let keys = Object.keys(objects[0]);
    let result = '<table>\n';
    result += '\t<tr>';

    for (const key of keys) {
        result += `<th>${escape(key)}</th>`;
    }

    result += '</tr>\n';

    for (const student of objects) {
        result += `\t<tr>`;
        for (const key of keys) {
            result += `<td>${escape(student[key])}</td>`;
        }
        result += '</tr>\n';
    }

    result += '</table>';

    function escape(value) {
        return value.toString().replace('<', '&lt;').replace('>', '&gt;').replace('&', '&amp;').replace('"', '&quot;');
    }

    return result;
}

console.log(solve(`[{"Name":"Pesho",
"Score":4,
"Grade":8},
{"Name":"Gosho&",
"Score":5,
"Grade":8},
{"Name":"Angel",
"Score":5.50,
"Grade":10}]`
));