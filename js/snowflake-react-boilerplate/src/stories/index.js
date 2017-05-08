import React from 'react'
import { storiesOf, action } from '@kadira/storybook'
import centered from '@kadira/react-storybook-decorator-centered'
import full from './utils/full'
import { MultiCard, SingleCard } from './components/GameCard.story'
import mui from './utils/mui'
import { blue, pink } from 'material-ui/styles/colors'

import { SearchBarStory, SearchBarStoryWithBackground } from './components/SearchBarStory.story'
import { Black, WhiteWithBackground } from './components/PlatformDisplay.story'
import { GameBlack, GameWhiteWithBackground } from './components/GameDisplay.story'
// import { GameDetailsStory } from './GameDetails.story'
import { BooleanConfigurationStory } from './components/Configuration.story'
import GameDetailsHeaderViewStory from './views/GameDetailsHeaderView.story'
import { SidebarStory } from './components/Sidebar.story'
import { GameGridViewStory } from './views/GameGridView.story'

import ImageCard from 'components/presentation/ImageCard'
import GamePlayButton from 'components/presentation/GamePlayButton'
const muiTheme = mui({ blue, pink })

storiesOf('Game Card', module)
  .addDecorator(centered)
  .addDecorator(muiTheme)
  .add('Multiple', () => <MultiCard />)
  .add('Single', () => <SingleCard />)

storiesOf('Platform Display', module)
  .addDecorator(full)
  .addDecorator(muiTheme)
  .add('on White', () => <Black />)
  .add('on Background', () => <WhiteWithBackground />)

storiesOf('Game Display', module)
  .addDecorator(full)
  .addDecorator(muiTheme)
  .add('on White', () => <GameBlack />)
  .add('on Background', () => <GameWhiteWithBackground />)

storiesOf('Search Bar', module)
  .addDecorator(centered)
  .addDecorator(muiTheme)
  .add('Search bar', () => <SearchBarStory />)
  .add('with Background', () => <SearchBarStoryWithBackground />)

storiesOf('Configuration', module)
  .addDecorator(centered)
  .addDecorator(muiTheme)
  .add('boolean widget', () => <BooleanConfigurationStory />)

storiesOf('Image Card', module)
  .addDecorator(centered)
  .addDecorator(muiTheme)
  .add('portrait', () =>
    <ImageCard
      image="http://vignette2.wikia.nocookie.net/mario/images/6/60/SMBBoxart.png/revision/latest?cb=20120609143443"
    />)
  .add('landscape', () =>
    <div>
    <ImageCard
      image="https://upload.wikimedia.org/wikipedia/en/3/32/Super_Mario_World_Coverart.png"
    />
    </div>)

storiesOf('Game Play Button', module)
  .addDecorator(centered)
  .addDecorator(muiTheme)
  .add('static', () =>
    <GamePlayButton
      onClick={action('button-clicked')} />
  )
  .add('loading', () =>
    <GamePlayButton
      onClick={action('button-clicked')}
      loading={true} />
  )

storiesOf('Game Details Header', module)
  .addDecorator(full)
  .addDecorator(muiTheme)
  .add('default', () =>
    <GameDetailsHeaderViewStory/>
  )
storiesOf('Sidebar', module)
  .addDecorator(full)
  .addDecorator(muiTheme)
  .add('default', () =>
    <SidebarStory/>
  )
storiesOf('Game Grid', module)
  .addDecorator(full)
  .addDecorator(muiTheme)
  .add('default', () =>
    <GameGridViewStory/>
  )
/*
storiesOf('Game Details', module)
  .addDecorator(centered)
  .add('on White', () => <GameDetailsStory/>)

 */
