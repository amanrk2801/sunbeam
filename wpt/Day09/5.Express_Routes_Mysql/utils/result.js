function createResult(error, data) {
    let result = {}
    if (data) {
        result["status"] = "success"
        result["data"] = data
    }
    else {
        result["status"] = "error"
        result["error"] = error
    }
    return result
}

module.exports = { createResult }