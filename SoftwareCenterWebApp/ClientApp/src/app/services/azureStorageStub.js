"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var rxjs_1 = require("rxjs");
var operators_1 = require("rxjs/operators");
exports.uploadProgressStub = 0;
exports.blobStorageStub = {
    createBlobServiceWithSas: function () { return blobService; },
    ExponentialRetryPolicyFilter: function () { }
};
var percentComplete = 0;
var speedSummary = {
    on: function (eventName, callback) {
        rxjs_1.interval(200)
            .pipe(operators_1.take(4), operators_1.map(function (intervalCount) { return 25 * (intervalCount + 1); }), operators_1.tap(function (progress) { return (percentComplete = progress); }), operators_1.tap(function (progress) {
            return progress === 100 ? (exports.uploadProgressStub = 99) : (exports.uploadProgressStub = progress);
        }))
            .subscribe(function () { return callback(); });
    },
    getCompletePercent: function () { return percentComplete.toString(); },
    getAverageSpeed: function () { return ''; },
    getSpeed: function () { return ''; }
};
var blobService = {
    createBlockBlobFromBrowserFile: function (container, filename, file, options, callback) {
        rxjs_1.timer(1000)
            .pipe(operators_1.tap(function () { return (exports.uploadProgressStub = 100); }))
            .subscribe(function () { return callback(container, ''); });
        return speedSummary;
    },
    withFilter: function () { return blobService; },
    singleBlobPutThresholdInBytes: 10
};
//# sourceMappingURL=azureStorageStub.js.map