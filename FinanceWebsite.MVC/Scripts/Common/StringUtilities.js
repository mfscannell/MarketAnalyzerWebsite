var StringUtilities = (function () {
    return {
        lowerCaseFirstLetter: function (aString) {
            if (aString !== null && aString !== undefined && aString.length >= 0) {
                return aString.charAt(0).toLowerCase() + aString.slice(1);
            }

            return aString;
        },
        upperCaseFirstLetter: function (aString) {
            if (aString !== null && aString !== undefined && aString.length >= 0) {
                return aString.charAt(0).toUpperCase() + aString.slice(1);
            }

            return aString;
        }
    }
})();