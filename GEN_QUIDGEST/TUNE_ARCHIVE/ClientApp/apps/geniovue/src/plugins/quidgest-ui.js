import { createFramework } from '@quidgest/ui/framework'

const framework = createFramework({
	themes: {
		defaultTheme: 'Light',
		themes: [
			{
				name: 'Light',
				mode: 'light',
				colors: {
					primaryDark: '#FF5300',
					highlight: '#304ffe',
					secondary: '#FF5F00',
					primary: '#2B2B2B',
					primaryLight: '#f5c8cc',
				}
			}
		]
	},
	defaults: {
		QIconSvg: {
			bundle: 'Content/svgbundle.svg?v=12'
		},
		QCollapsible: {
			icons: {
				chevron: {
					icon: 'expand'
				}
			}
		},
		QListItem: {
			icons: {
				check: {
					icon: 'ok'
				},
				description: {
					icon: 'help'
				}
			}
		},
		QSelect: {
			itemValue: 'key',
			itemLabel: 'value',
			icons: {
				clear: {
					icon: 'close'
				},
				chevron: {
					icon: 'expand'
				}
			}
		},
		QCombobox: {
			itemValue: 'key',
			itemLabel: 'value',
			icons: {
				clear: {
					icon: 'close'
				},
				chevron: {
					icon: 'expand'
				}
			}
		},
		QPropertyList: {
			icons: {
				open: {
					icon: 'square-minus',
				},
				close: {
					icon: 'square-plus',
				}
			}
		},
		QCheckbox: {
			icons: {
				checked: {
					icon: 'ok'
				},
				indeterminate: {
					icon: 'minus'
				}
			}
		},
		QCarousel: {
			icons: {
				back: {
					icon: 'step-back'
				},
				forward: {
					icon: 'step-forward'
				}
			}
		}
	}
})

export default framework
