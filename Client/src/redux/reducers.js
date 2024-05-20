import { createSlice } from '@reduxjs/toolkit';
import { language } from "../enum/EnumApi";

/**
 * Initial state for the language reducer.
 */
const initialState = {
  currentLanguage: language.english, // Default language is English
};

const languageSlice = createSlice({
  name: 'language',
  initialState,
  reducers: {
    changeLanguage: (state, action) => {
      state.currentLanguage = action.payload;
    },
  },
});

export const { changeLanguage } = languageSlice.actions;
export default languageSlice.reducer;