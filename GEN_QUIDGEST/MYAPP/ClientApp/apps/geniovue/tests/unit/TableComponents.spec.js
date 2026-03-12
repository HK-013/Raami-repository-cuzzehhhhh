import { within } from '@testing-library/dom'
import '@testing-library/jest-dom'
import { fireEvent } from '@testing-library/vue'
import { flushPromises } from '@vue/test-utils'
import cloneDeep from 'lodash-es/cloneDeep'
import { beforeEach, describe, expect, it, vi } from 'vitest'
import { nextTick } from 'vue'
import { render } from './utils'

import listFunctions from '@/mixins/listFunctions.js'
import fakeData from '../cases/Table.mock.js'

import QTableCurrentFilters from '@/components/table/QTableCurrentFilters.vue'
import QTableChecklistCheckbox from '@/components/table/QTableChecklistCheckbox.vue'
import QTableExport from '@/components/table/QTableExport.vue'
import QTableLimitInfo from '@/components/table/QTableLimitInfo.vue'
import QTablePagination from '@/components/table/QTablePagination.vue'
import QTablePaginationAlt from '@/components/table/QTablePaginationAlt.vue'
import QTableRecordActionsMenu from '@/components/table/QTableRecordActionsMenu.vue'
import QTableStaticFilters from '@/components/table/QTableStaticFilters.vue'

const global = {
	stubs: ['inline-svg']
}

let tableTest
beforeEach(() => (tableTest = fakeData.getTableTest()))

describe('QTableRecordActionsMenu.vue', () => {
	const setupWrapper = function (actionsMenu, displayType) {
		return render(QTableRecordActionsMenu, {
			global,
			props: {
				...actionsMenu,
				display: displayType || actionsMenu.display,
				texts: tableTest.texts
			}
		})
	}

	it('In normal mode with 0 actions, dropdown display, component has no menu or button', async () => {
		const actionsMenu = fakeData.actionsMenu0
		const wrapper = setupWrapper(actionsMenu, 'dropdown')

		await nextTick()

		// No button
		const button = await wrapper.queryByRole('button')
		expect(button).toBeNull()
	})

	it('In normal mode with 0 actions, inline display, component has no menu or button', async () => {
		const actionsMenu = fakeData.actionsMenu0
		const wrapper = setupWrapper(actionsMenu, 'inline')

		await nextTick()

		// No button
		const button = await wrapper.queryByRole('button')
		expect(button).toBeNull()
	})

	it('In normal mode with 0 actions, inlineAll display, component has no menu or button', async () => {
		const actionsMenu = fakeData.actionsMenu0
		const wrapper = setupWrapper(actionsMenu, 'inlineAll')

		await nextTick()

		// No button
		const button = await wrapper.queryByRole('button')
		expect(button).toBeNull()
	})

	it('In read-only mode with 1 action, 0 available in read-only, dropdown display, component has no button or menu', async () => {
		const actionsMenu = fakeData.actionsMenu1ReadOnly0
		const wrapper = setupWrapper(actionsMenu, 'dropdown')

		await nextTick()

		// No button
		const button = await wrapper.queryByRole('button')
		expect(button).toBeNull()
	})

	it('In read-only mode with 1 action, 0 available in read-only, inline display, component has no button or menu', async () => {
		const actionsMenu = fakeData.actionsMenu1ReadOnly0
		const wrapper = setupWrapper(actionsMenu, 'inline')

		await nextTick()

		// No button
		const button = await wrapper.queryByRole('button')
		expect(button).toBeNull()
	})

	it('In read-only mode with 1 action, 0 available in read-only, inlineAll display, component has no button or menu', async () => {
		const actionsMenu = fakeData.actionsMenu1ReadOnly0
		const wrapper = setupWrapper(actionsMenu, 'inlineAll')

		await nextTick()

		// No button
		const button = await wrapper.queryByRole('button')
		expect(button).toBeNull()
	})

	it('In read-only mode with 1 action, 1 available in read-only, dropdown display, component has button, clicking action emits action', async () => {
		const actionsMenu = fakeData.actionsMenu1ReadOnly1
		const idx = 0
		const wrapper = setupWrapper(actionsMenu, 'dropdown')

		await nextTick()

		// Get action reference (whether it is in custom actions or CRUD actions)
		const actionsMenuActions = actionsMenu.customActions.concat(actionsMenu.crudActions)
		const action = actionsMenuActions[idx]
		// Get and click button
		const button = await wrapper.findByRole('button')
		expect(button).toBeInTheDocument()
		await fireEvent.click(button)
		expect(wrapper.emitted()).toHaveProperty('row-action')
		expect(wrapper.emitted()['row-action'][0][0]['name']).toBe(action.name)
	})

	it('In read-only mode with 1 action, 1 available in read-only, inline display, component has button, clicking action emits action', async () => {
		const actionsMenu = fakeData.actionsMenu1ReadOnly1
		const idx = 0
		const wrapper = setupWrapper(actionsMenu, 'inline')

		await nextTick()

		// Get action reference (whether it is in custom actions or CRUD actions)
		const actionsMenuActions = actionsMenu.customActions.concat(actionsMenu.crudActions)
		const action = actionsMenuActions[idx]
		// Get and click button
		const button = await wrapper.findByRole('button')
		expect(button).toBeInTheDocument()
		await fireEvent.click(button)
		expect(wrapper.emitted()).toHaveProperty('row-action')
		expect(wrapper.emitted()['row-action'][0][0]['name']).toBe(action.name)
	})

	it('In read-only mode with 1 action, 1 available in read-only, inlineAll display, component has button, clicking action emits action', async () => {
		const actionsMenu = fakeData.actionsMenu1ReadOnly1
		const idx = 0
		const wrapper = setupWrapper(actionsMenu, 'inlineAll')

		await nextTick()

		// Get action reference (whether it is in custom actions or CRUD actions)
		const actionsMenuActions = actionsMenu.customActions.concat(actionsMenu.crudActions)
		const action = actionsMenuActions[idx]
		// Get and click button
		const button = await wrapper.findByRole('button')
		expect(button).toBeInTheDocument()
		await fireEvent.click(button)
		expect(wrapper.emitted()).toHaveProperty('row-action')
		expect(wrapper.emitted()['row-action'][0][0]['name']).toBe(action.name)
	})

	it('In read-only mode with N actions, 0 available in read-only, dropdown display, component has no button or menu', async () => {
		const actionsMenu = fakeData.actionsMenuNReadOnly0
		const wrapper = setupWrapper(actionsMenu, 'dropdown')

		await nextTick()

		// No button
		const button = await wrapper.queryByRole('button')
		expect(button).toBeNull()
	})

	it('In read-only mode with N actions, 0 available in read-only, inline display, component has no button or menu', async () => {
		const actionsMenu = fakeData.actionsMenuNReadOnly0
		const wrapper = setupWrapper(actionsMenu, 'inline')

		await nextTick()

		// No button
		const button = await wrapper.queryByRole('button')
		expect(button).toBeNull()
	})

	it('In read-only mode with N actions, 0 available in read-only, inlineAll display, component has no button or menu', async () => {
		const actionsMenu = fakeData.actionsMenuNReadOnly0
		const wrapper = setupWrapper(actionsMenu, 'inlineAll')

		await nextTick()

		// No button
		const button = await wrapper.queryByRole('button')
		expect(button).toBeNull()
	})

	it('In read-only mode with N actions, 1 available in read-only, dropdown display, component has button, clicking action emits action', async () => {
		const actionsMenu = fakeData.actionsMenuNReadOnly1
		const idx = 0
		const wrapper = setupWrapper(actionsMenu, 'dropdown')

		await nextTick()

		// Get action reference (whether it is in custom actions or CRUD actions)
		const actionsMenuActions = actionsMenu.customActions.concat(actionsMenu.crudActions)
		const action = actionsMenuActions[idx]
		// Get and click button
		const button = await wrapper.findByTestId('table-action')
		expect(button).toBeInTheDocument()
		await fireEvent.click(button)
		expect(wrapper.emitted()).toHaveProperty('row-action')
		expect(wrapper.emitted()['row-action'][0][0]['name']).toBe(action.name)
	})

	it('In read-only mode with N actions, 1 available in read-only, inline display, component has button, clicking action emits action', async () => {
		const actionsMenu = fakeData.actionsMenuNReadOnly1
		const idx = 0
		const wrapper = setupWrapper(actionsMenu, 'inline')

		await nextTick()

		// Get action reference (whether it is in custom actions or CRUD actions)
		const actionsMenuActions = actionsMenu.customActions.concat(actionsMenu.crudActions)
		const action = actionsMenuActions[idx]
		// Get and click button
		const button = await wrapper.findByTestId('table-action')
		expect(button).toBeInTheDocument()
		await fireEvent.click(button)
		expect(wrapper.emitted()).toHaveProperty('row-action')
		expect(wrapper.emitted()['row-action'][0][0]['name']).toBe(action.name)
	})

	it('In read-only mode with N actions, 1 available in read-only, inlineAll display, component has button, clicking action emits action', async () => {
		const actionsMenu = fakeData.actionsMenuNReadOnly1
		const idx = 0
		const wrapper = setupWrapper(actionsMenu, 'inlineAll')

		await nextTick()

		// Get action reference (whether it is in custom actions or CRUD actions)
		const actionsMenuActions = actionsMenu.customActions.concat(actionsMenu.crudActions)
		const action = actionsMenuActions[idx]
		// Get and click button
		const button = await wrapper.findByTestId('table-action')
		expect(button).toBeInTheDocument()
		await fireEvent.click(button)
		expect(wrapper.emitted()).toHaveProperty('row-action')
		expect(wrapper.emitted()['row-action'][0][0]['name']).toBe(action.name)
	})

	it('In read-only mode with N actions, N available in read-only, dropdown display, component has menu, clicking action emits action', async () => {
		const actionsMenu = fakeData.actionsMenuNReadOnlyN
		const idx = 0
		const wrapper = setupWrapper(actionsMenu, 'dropdown')

		await nextTick()

		// Get action reference (whether it is in custom actions or CRUD actions)
		const actionsMenuActions = actionsMenu.customActions.concat(actionsMenu.crudActions)
		const action = actionsMenuActions[idx]
		// Get and click toggle button
		const button = await wrapper.findByRole('button')
		expect(button).toBeInTheDocument()
		await fireEvent.click(button)
		// Get menu
		const menu = await wrapper.findByRole('menu')
		expect(menu).toBeInTheDocument()
		// Get and click action
		const actions = await wrapper.findAllByTestId('table-action')
		expect(actions[idx]).toBeInTheDocument()
		await fireEvent.click(actions[idx])
		expect(wrapper.emitted()).toHaveProperty('row-action')
		expect(wrapper.emitted()['row-action'][0][0]['name']).toBe(action.name)
	})

	it('In read-only mode with N actions, N available in read-only, inline display, component has multiple buttons, clicking action emits action', async () => {
		const actionsMenu = fakeData.actionsMenuNReadOnlyN
		const idx = 0
		const wrapper = setupWrapper(actionsMenu, 'inline')

		await nextTick()

		// Get action reference (whether it is in custom actions or CRUD actions)
		const actionsMenuActions = actionsMenu.customActions.concat(actionsMenu.crudActions)
		const numVisibleActions = listFunctions.numArrayVisibleActions(actionsMenuActions)
		const action = actionsMenuActions[idx]
		// Get and click button
		const buttons = await wrapper.findAllByTestId('table-action')
		expect(buttons).toHaveLength(numVisibleActions)
		await fireEvent.click(buttons[0])
		expect(wrapper.emitted()).toHaveProperty('row-action')
		expect(wrapper.emitted()['row-action'][0][0]['name']).toBe(action.name)
	})

	it('In read-only mode with N actions, N available in read-only, inlineAll display, component has multiple buttons, clicking action emits action', async () => {
		const actionsMenu = fakeData.actionsMenuNReadOnlyN
		const idx = 0
		const wrapper = setupWrapper(actionsMenu, 'inlineAll')

		await nextTick()

		// Get action reference (whether it is in custom actions or CRUD actions)
		const actionsMenuActions = actionsMenu.customActions.concat(actionsMenu.crudActions)
		const numVisibleActions = listFunctions.numArrayVisibleActions(actionsMenuActions)
		const action = actionsMenuActions[idx]
		// Get and click button
		const buttons = await wrapper.findAllByTestId('table-action')
		expect(buttons).toHaveLength(numVisibleActions)
		await fireEvent.click(buttons[0])
		expect(wrapper.emitted()).toHaveProperty('row-action')
		expect(wrapper.emitted()['row-action'][0][0]['name']).toBe(action.name)
	})
})

describe('QTableExport.vue', () => {
	it('File export menu item emits selected format', async () => {
		const dataOptions = fakeData.exportOptions01
		const wrapper = render(QTableExport, {
			global,
			props: {
				options: dataOptions,
				texts: tableTest.texts
			}
		})
		const idx = 0

		await nextTick()

		const button = await wrapper.findByRole('button')
		expect(button).toBeInTheDocument()
		// Click export button
		await fireEvent.click(button)
		// Get menu items
		const menuitems = await wrapper.findAllByRole('option')
		// Click export menu item and check emit
		await fireEvent.click(menuitems[idx])
		expect(wrapper.emitted()).toHaveProperty('export-data')
		expect(wrapper.emitted()['export-data'][0][0]).toBe(dataOptions[idx].id)
	})
})

describe('QTableStaticFilters.vue', () => {
	it('Selecting a filter radio button emits event to update filter values', async () => {
		const dataFilters = fakeData.groupFiltersSingle01
		const wrapper = render(QTableStaticFilters, {
			global,
			props: {
				groupFilters: dataFilters,
				texts: tableTest.texts,
				dateFormats: {
					date: 'dd/MM/yyyy',
					dateTime: 'dd/MM/yyyy HH:mm',
					dateTimeSeconds: 'dd/MM/yyyy HH:mm:ss',
					hours: 'HH:mm',
				}
			}
		})
		const idx = 0

		await nextTick()

		// Get filter control group
		const controlgroup = await wrapper.findByRole('radiogroup')
		expect(controlgroup).toBeInTheDocument()
		// Get filter controls
		const controls = await within(controlgroup).findAllByRole('radio')
		// Click filter control and check emit
		await fireEvent.click(controls[idx])
		expect(wrapper.emitted()).toHaveProperty('update:groupFilters')
	})

	it('Selecting a filter checkbox emits event to update filter values', async () => {
		const dataFilters = fakeData.groupFiltersMultiple01
		const wrapper = render(QTableStaticFilters, {
			global,
			props: {
				groupFilters: dataFilters,
				texts: tableTest.texts,
				dateFormats: {
					date: 'dd/MM/yyyy',
					dateTime: 'dd/MM/yyyy HH:mm',
					dateTimeSeconds: 'dd/MM/yyyy HH:mm:ss',
					hours: 'HH:mm',
				}
			}
		})
		const idx = 0

		await nextTick()

		// Get filter controls
		const controls = await wrapper.findAllByRole('checkbox')
		// Click filter control and check emit
		await fireEvent.click(controls[idx])
		expect(wrapper.emitted()).toHaveProperty('update:groupFilters')
	})

	it('Selecting an active filter checkbox emits event to update filter values', async () => {
		const dataFilters = fakeData.activeFilters01
		const wrapper = render(QTableStaticFilters, {
			global,
			props: {
				activeFilters: dataFilters,
				texts: tableTest.texts,
				dateFormats: {
					date: 'dd/MM/yyyy',
					dateTime: 'dd/MM/yyyy HH:mm',
					dateTimeSeconds: 'dd/MM/yyyy HH:mm:ss',
					hours: 'HH:mm',
				}

			}
		})
		const idx = 0

		await nextTick()

		// Get filter controls
		const controls = await wrapper.findAllByRole('checkbox')
		// Click filter control and check emit
		await fireEvent.click(controls[idx])

		await flushPromises()
		await vi.dynamicImportSettled()

		expect(wrapper.emitted()).toHaveProperty('update:activeFilters')
	})
})

describe('QTablePagination.vue', () => {
	it('Clicking first pagination button emits event and page number 1', async () => {
		const dataPagination = fakeData.paginationNormal01
		const wrapper = render(QTablePagination, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				numVisiblePaginationButtons: dataPagination.numVisiblePaginationButtons,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		// Click page button and check emit
		await fireEvent.click(buttons[0])
		expect(wrapper.emitted()).toHaveProperty('update:page')
		expect(wrapper.emitted()['update:page'][0][0]).toBe(1)
	})

	it('Clicking previous pagination button emits event and previous page number', async () => {
		const dataPagination = fakeData.paginationNormal01
		const wrapper = render(QTablePagination, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				numVisiblePaginationButtons: dataPagination.numVisiblePaginationButtons,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		// Click page button and check emit
		await fireEvent.click(buttons[1])
		expect(wrapper.emitted()).toHaveProperty('update:page')
		expect(wrapper.emitted()['update:page'][0][0]).toBe(dataPagination.page - 1)
	})

	it('Clicking current pagination button emits event and current page number', async () => {
		const dataPagination = fakeData.paginationNormal01
		const wrapper = render(QTablePagination, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				numVisiblePaginationButtons: dataPagination.numVisiblePaginationButtons,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		// Click page button and check emit
		await fireEvent.click(buttons[4])
		expect(wrapper.emitted()).toHaveProperty('update:page')
		expect(wrapper.emitted()['update:page'][0][0]).toBe(dataPagination.page)
	})

	it('Clicking next pagination button emits event and next page number', async () => {
		const dataPagination = fakeData.paginationNormal01
		const wrapper = render(QTablePagination, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				numVisiblePaginationButtons: dataPagination.numVisiblePaginationButtons,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		// Click page button and check emit
		await fireEvent.click(buttons[7])
		expect(wrapper.emitted()).toHaveProperty('update:page')
		expect(wrapper.emitted()['update:page'][0][0]).toBe(dataPagination.page + 1)
	})

	it('Clicking last pagination button emits event and last page number', async () => {
		const dataPagination = fakeData.paginationNormal01
		const wrapper = render(QTablePagination, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				numVisiblePaginationButtons: dataPagination.numVisiblePaginationButtons,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		// Click page button and check emit
		await fireEvent.click(buttons[8])
		expect(wrapper.emitted()).toHaveProperty('update:page')
		expect(wrapper.emitted()['update:page'][0][0]).toBe(
			dataPagination.rowCount / dataPagination.perPage
		)
	})

	it('Pagination with no rows has no buttons', async () => {
		const dataPagination = cloneDeep(fakeData.paginationNormal01)
		const wrapper = render(QTablePagination, {
			global,
			props: {
				page: 0,
				perPage: dataPagination.perPage,
				total: 0,
				numVisiblePaginationButtons: dataPagination.numVisiblePaginationButtons,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.queryAllByRole('button')
		expect(buttons).toHaveLength(0)
	})

	it.todo('Pagination on first page has first, previous, numbered pages, next, last buttons', async () => {
		const dataPagination = cloneDeep(fakeData.paginationNormal01)
		dataPagination.page = 1
		const wrapper = render(QTablePagination, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				numVisiblePaginationButtons: dataPagination.numVisiblePaginationButtons,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		expect(buttons[0].getAttribute('aria-label')).toBe(tableTest.texts.first.value)
		expect(buttons[1].getAttribute('aria-label')).toBe(tableTest.texts.previous.value)
		expect(buttons[2]).toHaveTextContent(dataPagination.page)
		expect(buttons[3]).toHaveTextContent(dataPagination.page + 1)
		expect(buttons[4]).toHaveTextContent(dataPagination.page + 2)
		expect(buttons[5]).toHaveTextContent(dataPagination.page + 3)
		expect(buttons[6]).toHaveTextContent(dataPagination.page + 4)
		expect(buttons[7].getAttribute('aria-label')).toBe(tableTest.texts.next.value)
		expect(buttons[8].getAttribute('aria-label')).toBe(tableTest.texts.last.value)
	})

	it.todo('Pagination on second page has first, previous, numbered pages, next, last buttons', async () => {
		const dataPagination = cloneDeep(fakeData.paginationNormal01)
		dataPagination.page = 2
		const wrapper = render(QTablePagination, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				numVisiblePaginationButtons: dataPagination.numVisiblePaginationButtons,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		expect(buttons[0].getAttribute('aria-label')).toBe(tableTest.texts.first.value)
		expect(buttons[1].getAttribute('aria-label')).toBe(tableTest.texts.previous.value)
		expect(buttons[2]).toHaveTextContent(dataPagination.page - 1)
		expect(buttons[3]).toHaveTextContent(dataPagination.page)
		expect(buttons[4]).toHaveTextContent(dataPagination.page + 1)
		expect(buttons[5]).toHaveTextContent(dataPagination.page + 2)
		expect(buttons[6]).toHaveTextContent(dataPagination.page + 3)
		expect(buttons[7].getAttribute('aria-label')).toBe(tableTest.texts.next.value)
		expect(buttons[8].getAttribute('aria-label')).toBe(tableTest.texts.last.value)
	})

	it.todo('Pagination on middle page has first, previous, numbered pages, next, last buttons', async () => {
		const dataPagination = cloneDeep(fakeData.paginationNormal01)
		const wrapper = render(QTablePagination, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				numVisiblePaginationButtons: dataPagination.numVisiblePaginationButtons,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		expect(buttons[0].getAttribute('aria-label')).toBe(tableTest.texts.first.value)
		expect(buttons[1].getAttribute('aria-label')).toBe(tableTest.texts.previous.value)
		expect(buttons[2]).toHaveTextContent(dataPagination.page - 2)
		expect(buttons[3]).toHaveTextContent(dataPagination.page - 1)
		expect(buttons[4]).toHaveTextContent(dataPagination.page)
		expect(buttons[5]).toHaveTextContent(dataPagination.page + 1)
		expect(buttons[6]).toHaveTextContent(dataPagination.page + 2)
		expect(buttons[7].getAttribute('aria-label')).toBe(tableTest.texts.next.value)
		expect(buttons[8].getAttribute('aria-label')).toBe(tableTest.texts.last.value)
	})

	it.todo('Pagination on second last page has first, previous, numbered pages, next buttons', async () => {
		const dataPagination = cloneDeep(fakeData.paginationNormal01)
		dataPagination.page = 9
		const wrapper = render(QTablePagination, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				numVisiblePaginationButtons: dataPagination.numVisiblePaginationButtons,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		expect(buttons[0].getAttribute('aria-label')).toBe(tableTest.texts.first.value)
		expect(buttons[1].getAttribute('aria-label')).toBe(tableTest.texts.previous.value)
		expect(buttons[2]).toHaveTextContent(dataPagination.page - 3)
		expect(buttons[3]).toHaveTextContent(dataPagination.page - 2)
		expect(buttons[4]).toHaveTextContent(dataPagination.page - 1)
		expect(buttons[5]).toHaveTextContent(dataPagination.page)
		expect(buttons[6]).toHaveTextContent(dataPagination.page + 1)
		expect(buttons[7].getAttribute('aria-label')).toBe(tableTest.texts.next.value)
	})

	it.todo('Pagination on last page has first, previous, numbered pages buttons', async () => {
		const dataPagination = cloneDeep(fakeData.paginationNormal01)
		dataPagination.page = 10
		const wrapper = render(QTablePagination, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				numVisiblePaginationButtons: dataPagination.numVisiblePaginationButtons,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		expect(buttons[0].getAttribute('aria-label')).toBe(tableTest.texts.first.value)
		expect(buttons[1].getAttribute('aria-label')).toBe(tableTest.texts.previous.value)
		expect(buttons[2]).toHaveTextContent(dataPagination.page - 4)
		expect(buttons[3]).toHaveTextContent(dataPagination.page - 3)
		expect(buttons[4]).toHaveTextContent(dataPagination.page - 2)
		expect(buttons[5]).toHaveTextContent(dataPagination.page - 1)
		expect(buttons[6]).toHaveTextContent(dataPagination.page)
	})
})

describe('QTablePaginationAlt.vue', () => {
	it('Clicking first pagination button emits event and page number 1', async () => {
		const dataPagination = fakeData.paginationAlt01
		const wrapper = render(QTablePaginationAlt, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				hasMorePages: dataPagination.hasMore,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		// Click page button and check emit
		await fireEvent.click(buttons[0])
		expect(wrapper.emitted()).toHaveProperty('update:page')
		expect(wrapper.emitted()['update:page'][0][0]).toBe(1)
	})

	it('Clicking previous pagination button emits event and previous page number', async () => {
		const dataPagination = fakeData.paginationAlt01
		const wrapper = render(QTablePaginationAlt, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				hasMorePages: dataPagination.hasMore,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		// Click page button and check emit
		await fireEvent.click(buttons[1])
		expect(wrapper.emitted()).toHaveProperty('update:page')
		expect(wrapper.emitted()['update:page'][0][0]).toBe(dataPagination.page - 1)
	})

	it('Clicking next pagination button emits event and next page number', async () => {
		const dataPagination = fakeData.paginationAlt01
		const wrapper = render(QTablePaginationAlt, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				hasMorePages: dataPagination.hasMore,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		// Click page button and check emit
		await fireEvent.click(buttons[2])
		expect(wrapper.emitted()).toHaveProperty('update:page')
		expect(wrapper.emitted()['update:page'][0][0]).toBe(dataPagination.page + 1)
	})

	it('Pagination with no rows shows has no buttons', async () => {
		const dataPagination = cloneDeep(fakeData.paginationAlt01)
		dataPagination.rowCount = 0
		dataPagination.hasMore = false
		const wrapper = render(QTablePaginationAlt, {
			global,
			props: {
				page: 1,
				perPage: dataPagination.perPage,
				total: 0,
				hasMorePages: false,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.queryAllByRole('button')
		expect(buttons).toHaveLength(0)
	})

	it.todo('Pagination on first page has next button', async () => {
		const dataPagination = cloneDeep(fakeData.paginationAlt01)
		dataPagination.page = 1
		const wrapper = render(QTablePaginationAlt, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				hasMorePages: dataPagination.hasMore,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		expect(buttons[0].getAttribute('aria-label')).toBe(tableTest.texts.first.value)
		expect(buttons[1].getAttribute('aria-label')).toBe(tableTest.texts.previous.value)
		expect(buttons[2].getAttribute('aria-label')).toBe(tableTest.texts.next.value)
	})

	it.todo('Pagination on second page has first, previous, next buttons', async () => {
		const dataPagination = cloneDeep(fakeData.paginationAlt01)
		dataPagination.page = 2
		const wrapper = render(QTablePaginationAlt, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				hasMorePages: dataPagination.hasMore,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		expect(buttons[0].getAttribute('aria-label')).toBe(tableTest.texts.first.value)
		expect(buttons[1].getAttribute('aria-label')).toBe(tableTest.texts.previous.value)
		expect(buttons[buttons.length - 1].getAttribute('aria-label')).toBe(tableTest.texts.next.value)
	})

	it.todo('Pagination on middle page has first, previous, next buttons', async () => {
		const dataPagination = cloneDeep(fakeData.paginationAlt01)
		const wrapper = render(QTablePaginationAlt, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				hasMorePages: dataPagination.hasMore,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		expect(buttons[0].getAttribute('aria-label')).toBe(tableTest.texts.first.value)
		expect(buttons[1].getAttribute('aria-label')).toBe(tableTest.texts.previous.value)
		expect(buttons[2].getAttribute('aria-label')).toBe(tableTest.texts.next.value)
	})

	it.todo('Pagination on last page has first, previous buttons', async () => {
		const dataPagination = cloneDeep(fakeData.paginationAlt01)
		dataPagination.page = 10
		const wrapper = render(QTablePaginationAlt, {
			global,
			props: {
				page: dataPagination.page,
				perPage: dataPagination.perPage,
				total: dataPagination.rowCount,
				hasMorePages: dataPagination.hasMore,
				texts: tableTest.texts
			}
		})

		await nextTick()

		// Get page buttons
		const buttons = await wrapper.findAllByRole('button')
		expect(buttons[0].getAttribute('aria-label')).toBe(tableTest.texts.first.value)
		expect(buttons[1].getAttribute('aria-label')).toBe(tableTest.texts.previous.value)
	})
})

describe('QTableLimitInfo.vue', () => {
	it('Limits info dropdown displays list of limit', async () => {
		const dataLimits = fakeData.tableLimits01
		const dataText = fakeData.tableLimitsText01
		const wrapper = render(QTableLimitInfo, {
			global,
			props: {
				limits: dataLimits,
				tableNamePlural: dataText.tableNamePlural,
				texts: tableTest.texts
			}
		})

		await nextTick()

		const button = await wrapper.findByRole('button')
		expect(button).toBeInTheDocument()
		// Click button
		await fireEvent.click(button)
		// Get list items
		const listitems = await wrapper.findAllByRole('listitem')
		expect(listitems).toHaveLength(dataLimits.length + 1)
	})
})

describe('QTableChecklistCheckbox.vue', () => {
	it('Clicking row checklist checkbox emits event to toggle selecting row', async () => {
		const dataCheckbox = fakeData.checklistCheckboxRow01
		const wrapper = render(QTableChecklistCheckbox, {
			global,
			props: {
				value: dataCheckbox.value,
				tableName: dataCheckbox.tableName,
				readonly: dataCheckbox.readonly,
				rowKey: dataCheckbox.rowKey,
				texts: tableTest.texts
			}
		})

		await nextTick()

		const checkbox = await wrapper.findByRole('checkbox')
		expect(checkbox).toBeInTheDocument()
		// Click checkbox
		await fireEvent.click(checkbox)
		// Check emit
		expect(wrapper.emitted()).toHaveProperty('toggle-row-selected')
	})

	it('Clicking header checklist checkbox does not change its value and does not emit event to toggle selecting row', async () => {
		const dataCheckbox = fakeData.checklistCheckboxRow01
		const wrapper = render(QTableChecklistCheckbox, {
			global,
			props: {
				value: dataCheckbox.value,
				tableName: dataCheckbox.tableName,
				readonly: dataCheckbox.readonly,
				texts: tableTest.texts
			}
		})

		await nextTick()

		const checkbox = await wrapper.findByRole('checkbox')
		expect(checkbox).toBeInTheDocument()
		// Click checkbox
		await fireEvent.click(checkbox)
		// Check emit
		expect(wrapper.emitted('toggle-row-selected')).toBeUndefined()
		// Check checkbox value
		expect(checkbox.value).toBeFalsy()
	})
})

describe('QTableCurrentFilters.vue', () => {
	it('Configuration with advanced filters, column filters and searchbar filter show tag for each filter and tag to remove all filters', async () => {
		const dataFilters = fakeData.filterArray01
		const hasFiltersActive = true
		const searchableColumns = fakeData.searchableColumns01
		const wrapper = render(QTableCurrentFilters, {
			global,
			props: {
				searchableColumns: searchableColumns,
				filters: dataFilters,
				hasFiltersActive: hasFiltersActive,
				texts: tableTest.texts
			}
		})
		const filterCount = dataFilters.length

		await nextTick()

		const badges = await wrapper.findAllByTestId('table-filter')
		expect(badges).toHaveLength(filterCount)
	})

	it('Clicking the remove all filters tag emits update event to remove all filters', async () => {
		const dataFilters = fakeData.filterArray01
		const hasFiltersActive = true
		const searchableColumns = fakeData.searchableColumns01
		const wrapper = render(QTableCurrentFilters, {
			global,
			props: {
				searchableColumns: searchableColumns,
				filters: dataFilters,
				hasFiltersActive: hasFiltersActive,
				texts: tableTest.texts
			}
		})

		await nextTick()

		const clearBadge = await wrapper.findByTestId('clear-filters')
		// Click badge
		await fireEvent.click(clearBadge)
		// Check emit
		expect(wrapper.emitted()).toHaveProperty('update:filters')
		expect(wrapper.emitted()['update:filters'][0][0]).toStrictEqual([])
	})

	it('Clicking advanced filter tag emits event to edit filter', async () => {
		const dataFilters = fakeData.filterArray01
		const hasFiltersActive = true
		const searchableColumns = fakeData.searchableColumns01
		const wrapper = render(QTableCurrentFilters, {
			global,
			props: {
				searchableColumns: searchableColumns,
				filters: dataFilters,
				hasFiltersActive: hasFiltersActive,
				texts: tableTest.texts
			}
		})
		const idx = 0

		await nextTick()

		const badges = await wrapper.findAllByTestId('table-filter')
		// Click badge
		await fireEvent.click(badges[idx])
		// Check emit
		expect(wrapper.emitted()).toHaveProperty('show-filters')
		expect(wrapper.emitted()['show-filters'][0][0]).toStrictEqual(idx)
	})
})
