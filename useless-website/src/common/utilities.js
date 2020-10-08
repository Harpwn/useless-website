export function CalculateAverageTier(values) {

    let averageScore = 0;
    let totalCount = 0;
    values.forEach(val => {
        totalCount += val.valueCount;
        switch (val.id) {
            case 0:
                averageScore += 7 * val.valueCount;
                break;
            case 1:
                averageScore += 6 * val.valueCount;
                break;
            case 2:
                averageScore += 5 * val.valueCount;
                break;
            case 3:
                averageScore += 4 * val.valueCount;
                break;
            case 4:
                averageScore += 3 * val.valueCount;
                break;
            case 5:
                averageScore += 2 * val.valueCount;
                break;
            case 6:
                averageScore += 1 * val.valueCount;
                break;
            case 7:
                averageScore += 0 * val.valueCount;
                break;
            default:
                break;
        }
    });

    averageScore = (averageScore / totalCount);

    if (averageScore < 1)
        return 7;

    if (averageScore < 2)
        return 6;

    if (averageScore < 3)
        return 5;

    if (averageScore < 4)
        return 4;

    if (averageScore < 5)
        return 3;

    if (averageScore < 6)
        return 2;

    if (averageScore < 7)
        return 1;

    return 0;

}