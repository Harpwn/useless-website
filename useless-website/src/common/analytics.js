import ReactGA from 'react-ga';


export function initAnalytics(codeSuffix){
    var globalCode = process.env.REACT_APP_GA_CODE_GLOBAL;
    var siteCode = process.env.REACT_APP_GA_CODE + '-' + codeSuffix;

    if(siteCode) {
        if(globalCode) {
            ReactGA.initialize([{globalCode},{siteCode}])
        }

        ReactGA.initialize(siteCode);
        ReactGA.pageview(window.location.pathname + window.location.search);
    }

}