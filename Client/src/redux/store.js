import { configureStore } from "@reduxjs/toolkit";
import languageSlice from "./reducers";

/**
 * Configures the Redux store for the application.
 */
const store = configureStore({
    reducer:{
        language: languageSlice,
    }
})

export default store;