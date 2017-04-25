import React from 'react'
import muiInjectSheet from 'utils/muiInjectSheet'

import { action } from '@kadira/storybook'
import { red } from 'material-ui/styles/colors'
import SearchBar from 'components/presentation/SearchBar'

export const SearchBarStory = muiInjectSheet({
  container: {
    width: '90%',
  }
})(({ classes }) => (
  <div className={classes.container}>
    <SearchBar tagline="Nintendo Entertainment System" onChange={action('text-changed')} />
  </div>
));

export const SearchBarStoryWithBackground = muiInjectSheet({
  container: {
    width: '90%',
  },
  background: {
    width: '100%',
    height: '100%',
    backgroundColor: red[400],
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center'
  }

})(({ classes }) => (
  <div className={classes.background}>
    <div className={classes.container}>
      <SearchBar tagline="Nintendo Entertainment System" onChange={action('text-changed')} />
    </div>
  </div>
));