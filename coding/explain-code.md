# Rolle

Software-Entwicklung (JavaScript)

# Aufgabe

Wir haben vorliegenden Code, den wir nicht kennen und nicht verstehen.
Erkläre uns diesen Code.

```JS
        if ((Jahr == "") || (Jahr == null)) { Jahr = new Date().getYear() }

        if ((Jahr < 1970) || (2099 < Jahr)) {  return "Datum muss zwischen 1970 und 2099 liegen"; }

        if ((TagesDifferenz == "") || (TagesDifferenz == null)) { TagesDifferenz = 0; }

        var a = Jahr % 19;
        var d = (19 * a + 24) % 30;
        var Tag = d + (2 * (Jahr % 4) + 4 * (Jahr % 7) + 6 * d + 5) % 7;
        if ((Tag == 35) || ((Tag == 34) && (d == 28) && (a > 10))) { Tag -= 7; }

        var datum = new Date(Jahr, 2, 22)
        datum.setTime(datum.getTime() + 86400000 * TagesDifferenz + 86400000 * Tag)

        datum = datum.toLocaleString()
        datum = datum.substring(0, datum.length - 9);
        return datum;
```
