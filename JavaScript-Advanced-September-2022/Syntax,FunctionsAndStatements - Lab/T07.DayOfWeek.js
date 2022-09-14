function findDayOfWeek(input) {
    if (input === 'Monday') {
        return '1'
    } else if (input === 'Tuesday') {
        return '2';
    } else if (input === 'Wednesday') {
        return '3';
    } else if (input === 'Thursday') {
        return '4';
    } else if (input === 'Friday') {
        return '5';
    } else if (input === 'Saturday') {
        return '6';
    } else if (input === 'Sunday') {
        return '7';
    } else {
        return 'error';
    }
}