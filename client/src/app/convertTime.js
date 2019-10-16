export default function convertTime(time) {
    if(time < 60) {
        return `${time}m`
    } else {
        var r;
        r = parseInt(time/60) +"h "
        if(time%60 !== 0) {
            r += time%60 + "m";
        }
        return r;
    }
}
