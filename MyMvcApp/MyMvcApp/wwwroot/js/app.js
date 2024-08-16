$(document).ready(function () {
    const genderOptions = [1, 2];
    const hobiOptions = ['A', 'B', 'C', 'D', 'E'];
    const umurOptions = [...Array(23).keys()].map(i => i + 18); // Range 18-40

    function generateRandomString(length) {
        let result = '';
        const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        const charactersLength = characters.length;
        for (let i = 0; i < length; i++) {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        return result;
    }

    $('#generateButton').click(function () {
        const tbody = $('#dataTable tbody');
        tbody.empty();
        for (let i = 0; i < 1000; i++) {
            const id = i + 1;
            const nama = generateRandomString(8);
            const idGender = genderOptions[Math.floor(Math.random() * genderOptions.length)];
            const idHobi = hobiOptions[Math.floor(Math.random() * hobiOptions.length)].toString();
            const umur = umurOptions[Math.floor(Math.random() * umurOptions.length)];
            const row = `<tr>
                <td>${id}</td>
                <td>${nama}</td>
                <td>${idGender}</td>
                <td>${idHobi}</td>
                <td>${umur}</td>
            </tr>`;
            tbody.append(row);
        }
        $('#submitButton').prop('disabled', false);
    });

    $('#submitButton').click(function () {
        const data = [];
        $('#dataTable tbody tr').each(function () {
            const row = $(this).find('td');
            const item = {
                Id: parseInt(row.eq(0).text()),
                Nama: row.eq(1).text(),
                IdGender: parseInt(row.eq(2).text()),
                IdHobi: row.eq(3).text(),
                Umur: parseInt(row.eq(4).text())
            };
            data.push(item);
        });

        $.ajax({
            url: 'https://localhost:5001/api/personal/submit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function () {
                alert('Data submitted successfully!');
            },
            error: function (xhr, status, error) {
                console.error('Error: ' + error);
                console.error('Response: ' + xhr.responseText);
                alert('Error submitting data.');
            }
        });
    });
});